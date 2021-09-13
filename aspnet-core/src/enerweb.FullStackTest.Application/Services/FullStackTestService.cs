using AutoMapper;
using enerweb.FullStackTest.Dto.Models;
using enerweb.FullStackTest.EntityFrameworkCore;
using enerweb.FullStackTest.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using File = enerweb.FullStackTest.Dto.Models.File;

namespace enerweb.FullStackTest.Services
{
    public class FullStackTestService :  ApplicationService, IFullStackTestService
    {
        private readonly IRepository<Models.Header, int> _headerService;
        private readonly IRepository<Models.OperatingDateRecord, int> _operationDateRecordService;
        private readonly IRepository<Models.ProfileMeteringPeriod, int> _profileMeteringPeriodService;
        private readonly IRepository<Models.ServicePoint, int> _servicePointService;
        private readonly IRepository<Models.Trailer, int> _trailerService;
        //private readonly IHttpContextAccessor _httpContextAccessor;
        public FullStackTestService(IRepository<Models.Header, int> headerService,
                                    IRepository<Models.OperatingDateRecord, int> operationDateRecordService,
                                    IRepository<Models.ProfileMeteringPeriod, int> profileMeteringPeriodService,
                                    IRepository<Models.ServicePoint, int> servicePointService,
                                    IRepository<Models.Trailer, int> trailerService
                                    //IHttpContextAccessor httpContextAccessor
                                    )
        {
            _headerService = headerService;
            _operationDateRecordService = operationDateRecordService;
            _profileMeteringPeriodService = profileMeteringPeriodService;
            _servicePointService = servicePointService;
            _trailerService = trailerService;
            //_httpContextAccessor = httpContextAccessor;
        }

        private async Task<Record> QueryFileAsync(int id)
        {
            var header = await _headerService.GetQueryableAsync();
            var operationDate = await _operationDateRecordService.GetQueryableAsync();
            var servicePoint = await _servicePointService.GetQueryableAsync();
            var profileMetering = await _profileMeteringPeriodService.GetQueryableAsync();
            var trailer = await _trailerService.GetQueryableAsync();

            var query = new Record
                        {
                            Header =(from h in header where h.Id.Equals(id)
                                     select new Header
                                     {
                                         Id = h.Id,
                                         UserID = h.UserID,
                                         FileType = h.FileType,
                                         CreationDateTime = h.CreationDateTime,
                                         FileName = h.FileName,
                                         Unkonwn = h.Unkonwn
                                     }).FirstOrDefault(),

                            OperatingDateRecord = (from o in operationDate where o.HeaderId.Equals(id) select 
                                                  new OperatingDateRecord
                                                  {
                                                      Id = o.Id,
                                                      RecordType = o.RecordType,
                                                      OperatingDate = o.OperatingDate
                                                  }).FirstOrDefault(),

                            ServicePoint = (from s in servicePoint where s.HeaderId.Equals(id) select 
                                           new ServicePoint
                                           {
                                               Id = s.Id,
                                               RecordType = s.RecordType,
                                               MeterID = s.MeterID,
                                               MeterSerialNumber = s.MeterSerialNumber
                                           }).ToList(),

                            ProfileMeteringPeriods = (from p in profileMetering where p.HeaderId.Equals(id) select
                                                     new ProfileMeteringPeriod
                                                     {
                                                     
                                                     }).ToList(),

                            Trailer = (from t in trailer where t.HeaderId.Equals(id) select
                                      new Trailer
                                      {
                                          Id = t.Id,
                                          RecordType = t.RecordType,
                                          RecordCount = t.RecordCount
                                      }).FirstOrDefault()
                        };

            return query;
        }

        public async Task<Record> GetDocAsync(int id)
        {
            return await QueryFileAsync(id);
        }

        public async Task<object> SaveFileContentAsync([FromForm(Name = "file")] IFormFile formFile)
        {
            var lines = new List<string>();
            try
            {
                using (var content = new StreamReader(formFile.OpenReadStream()))
                {
                    while (content.Peek() >= 0)
                    {
                        lines.Add(content.ReadLine());
                    }
                }
            } 
            catch(Exception e)
            {
                throw new Exception("Could not process the file", e);
            }

            if (!lines[0].StartsWith("\"A00\""))
            {
                throw new Exception("File is missing a header");
            }

            else if (!lines[1].StartsWith("\"S10\""))
            {
                throw new Exception("File is missing an Operating Date");
            }

            int headerID = 0;
            if (lines.Count > 0)
            {
                foreach (string x in lines)
                {
                    var record = x.Replace("\"", string.Empty).Split(',');
                    if (x.Equals(lines[0]) || record[0].Equals("A00"))
                    {
                        string[] date = (record[3].Insert(4, "-").Insert(7, "-").Insert(10, "-").Insert(13, "-").Insert(16,"-")).Split("-");
                        var head = await _headerService.InsertAsync(new Models.Header
                        {
                            RecordType = record[0],
                            UserID = record[1],
                            FileType = record[2],
                            CreationDateTime = new DateTime(Convert.ToInt32(date[0]), Convert.ToInt32(date[1]), Convert.ToInt32(date[2]), Convert.ToInt32(date[3]), Convert.ToInt32(date[4]), Convert.ToInt32(date[5])),
                            Unkonwn = null,
                            FileName = formFile.FileName
                        }, autoSave: true);

                        headerID = head.Id;
                    }
                    else if (x.Equals(lines[1]) || record.Equals("S10"))
                    {
                        await _operationDateRecordService.InsertAsync(new Models.OperatingDateRecord
                        {
                            RecordType = record[0],
                            OperatingDate = DateTime.Parse(record[1].Insert(4, "-").Insert(7, "-")),
                            HeaderId = headerID
                        }, autoSave: true);
                    }
                    else if (x.Equals(lines.Count) || record[0].Equals("Z99"))
                    {
                        await _trailerService.InsertAsync(new Models.Trailer
                        {
                            RecordType = record[0],
                            RecordCount = (Convert.ToInt64(record[1]) - 2),
                            HeaderId = headerID
                        }, autoSave: true);
                    }
                    else if (record[0].Equals("S12"))
                    {
                        await _servicePointService.InsertAsync(new Models.ServicePoint
                        {
                            MeterID = record[0],
                            MeterSerialNumber = record[1],
                            HeaderId = headerID
                        }, autoSave: true);
                    }
                    else
                    {
                        if(record.Length == 9)
                        {
                            await _profileMeteringPeriodService.InsertAsync(new Models.ProfileMeteringPeriod
                            {
                                RecordType = record[0],
                                Period = int.Parse(record[1]),
                                ImportEnergy = float.Parse(record[2]),
                                ExportEnergy = float.Parse(record[3]),
                                ReactiveEnergyLeadingQ2 = float.Parse(record[4]),
                                ReactiveEnergyLeadingQ4 = float.Parse(record[5]),
                                ReactiveEnergyLaggingQ3 = float.Parse(record[6]),
                                ReactiveEnergyLaggingQ1 = float.Parse(record[7]),
                                ReadingFlag = float.Parse(record[8]),
                                HeaderId = headerID
                            }, autoSave: true);
                        }
                        
                    }
                }
            }

            return Task.FromResult(new { HeaderID = headerID });
        }

        public async Task<List<File>> GetFiles()
        {
            var header = await _headerService.GetQueryableAsync();

            var query = (from h in header
                        select new File
                        {
                            Id = h.Id,
                            Name = h.FileName
                        }).ToList();

            return query;
        }
    }
}
