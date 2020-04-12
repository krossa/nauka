# use an existing docker image as a base
FROM alpine

# download and install dependency
RUN apk add --update redis

# tell the image what to do when it starts as container
CMD ["redis-server"]