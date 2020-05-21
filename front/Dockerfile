FROM node:12.13.0-alpine as build
WORKDIR /app
EXPOSE 80

ENV NODE_OPTIONS=--max_old_space_size=4096
ENV NODE_ENV=production
ENV GENERATE_SOURCEMAP=false

COPY package.json /app/
COPY yarn.lock /app/

RUN yarn install --silent --frozen-lockfile --ignore-optional

COPY . /app

RUN yarn run build

FROM nginx:1.17.5-alpine
VOLUME /var/cache/nginx

COPY --from=build /app/build /usr/share/nginx/html
COPY ./nginx.conf /etc/nginx/conf.d/default.conf

# 'deamon off' is required "in order for nginx to stay in the foreground, so that Docker can track the process properly"
CMD ["nginx", "-g", "daemon off;"]