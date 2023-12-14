FROM node:18
RUN npm install --global nodemon
WORKDIR /social-v2-upload
COPY . .
RUN yarn install
EXPOSE 3854
CMD yarn start
