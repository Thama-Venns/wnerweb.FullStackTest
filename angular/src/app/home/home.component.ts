import { Component, OnInit } from '@angular/core';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})

export class HomeComponent implements OnInit {
  errorMessage: string;
  fileName: string;
  formData = new FormData();
  result: any;
  loadedFileId: string;
  files: any;

  constructor(private readonly apiService: ApiService) {}

  ngOnInit(): void {
    this.getFiles();
  }

  getFiles() {
    this.apiService.getFiles().subscribe((response: any) => {
      this.files = response;
      console.log(this.files)
    }, error => {
      alert(error.message);
    });
  }

  getFile(id: string) {
    this.apiService.getFileById(id).subscribe((response) => {
      this.result = response;
      console.log(this.result)
    }, error => {
      alert(error.message)
    })
  }

  cancel() {
    this.fileName = null;
    this.formData.delete("file");
  }

  submit() {
    if(this.formData.has("file")) {
      alert("Uploading File...")
      this.apiService.submitFile(this.formData).toPromise().then((result: any) => {
        this.loadedFileId = `${result.result.headerID}`
      }, error => {
        console.log(error)
      })
    }
  }

  onFileSelected(event) {
    this.errorMessage = null;
    const file:File = event.target.files[0];
    if (file) {
        let file_ext = file.name.split(".")[1]
        if(file_ext !== "pmr") {
          this.errorMessage = "Invalid file type, Please upload a pmr file."
          return
        }
        
        this.fileName = file.name;
        this.formData.append("file", file);
    }
  }

  reset() {
    this.result = null;
  }
}
