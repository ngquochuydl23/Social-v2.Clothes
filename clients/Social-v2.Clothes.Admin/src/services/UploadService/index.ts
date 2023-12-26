import axios, { AxiosProgressEvent } from "axios";
import _ from "lodash";
import { ErrorResult, HttpResult } from "services/https/dtos";
import settings from "services/settings";
import { ResponseUploadMediaDto } from "./dtos";


export const http = axios.create({
  baseURL: settings.mediaAPI
})

http.interceptors.request.use(async function (config: any) {
  config.headers['Content-Type'] = `multipart/form-data`
  config.headers['Access-Control-Allow-Origin'] = `*`
  config.headers['Access-Control-Allow-Credentials'] = `true`
  return config;
}, function (error) {
  return Promise.reject(error);
});

http.interceptors.response.use(function (response) {
  return response.data;
}, function (error) {
  if (_.has(error, 'response.data.error')) {
    const resError = _.get(error, 'response.data.error') as ErrorResult
    const dispatch = _.get(global, 'dispatch')
    return Promise.reject(resError)
  }
  return Promise.reject(error);
});

export const uploadMedia = (file: any, progress?: (loaded: number, total: number) => any)
  : Promise<HttpResult<ResponseUploadMediaDto>> => {
  return uploadMedias(new Array(file), progress);
}

export const uploadMedias = (files: any[], progress?: (loaded: number, total: number) => any): Promise<HttpResult<ResponseUploadMediaDto>> => {
  var bodyFormData = new FormData();

  files.forEach(file => {
    if (Boolean(file)) {
      bodyFormData.append('', file);
    }
  });

  return http.post('/upload', files, {
    onUploadProgress: progressEvent => {
      if (progress)
        progress(progressEvent.loaded, progressEvent.total!)
    }
  });
}