import axios, { AxiosHeaders } from "axios"
import setting from "../settings";
import _, { head } from "lodash";

export const http = axios.create({
  baseURL: setting.apiBaseURL
})

export const saveAccessToken = (accessToken) =>
  localStorage.setItem('social-v2.clothes.admin.sessionToken', accessToken)

export const getAccessToken = () =>
  localStorage.getItem('social-v2.clothes.admin.sessionToken')

export const clearAccessToken = () =>
  localStorage.removeItem('social-v2.clothes.admin.sessionToken')

async function onFulfilledReq(config) {
  const accessToken = getAccessToken();

  config.headers['Authorization'] = `Bearer ${accessToken}`
  config.headers['Content-Type'] = `application/json-patch+json`
  config.headers['accept'] = `*/*`

  return config;
}

async function onRejectedReq(error) {
  console.log(error)
  return Promise.reject(error);
}


async function onFulfilledRes(response) {
  return response.data;
}

async function onRejectedRes(error) {
  if (_.has(error, 'response.data.error')) {

    const resError = _.get(error, 'response.data.error')
    console.log("http.interceptors.response", { resError })
    const dispatch = _.get(global, 'dispatch')
    //dispatch?.(globalErrorActions.pushResponseError(resError))
    return Promise.reject(resError)
  }
  return Promise.reject(error);
}


http.interceptors.request.use(onFulfilledReq, onRejectedReq);
http.interceptors.response.use(onFulfilledRes, onRejectedRes);

httpChat.interceptors.request.use(onFulfilledReq, onRejectedReq);
httpChat.interceptors.response.use(onFulfilledRes, onRejectedRes);


