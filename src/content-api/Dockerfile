FROM golang:1.19 AS build
WORKDIR /app
COPY . /app
RUN CGO_ENABLED=0 GOOS=linux go build -o content-api main.go

FROM scratch
WORKDIR /app
COPY --from=build /app/content-api ./
COPY --from=build /app/docs ./
EXPOSE 3000

ENV DB-DATABASE=content
ENV DB-HOST=host.docker.internal
ENV DB-PASSWORD=?8@dtjFy#XCQ9
ENV DB-PORT=1433
ENV DB-USER=sa
ENV PORT=3000

CMD [ "./content-api" ]