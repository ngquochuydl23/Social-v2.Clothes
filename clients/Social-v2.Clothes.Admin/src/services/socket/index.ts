import settings from "../settings";

const { Manager } = require("socket.io-client");


export const socketManager = (namespace: string, options?: any) => {
  return new Manager(settings.chatSocketURL, {
  }).socket('/' + namespace, {
    auth: {
      token: localStorage.getItem('social-v2.sessionToken')
    },
    transports: ["websocket", "polling"],
    ...options
  })
}