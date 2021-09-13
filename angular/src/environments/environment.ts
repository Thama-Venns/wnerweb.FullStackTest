import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'FullStackTest',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44334',
    redirectUri: baseUrl,
    clientId: 'FullStackTest_App',
    responseType: 'code',
    scope: 'offline_access openid profile role email phone FullStackTest',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44334',
      rootNamespace: 'enerweb.FullStackTest',
    },
  },
} as Environment;
