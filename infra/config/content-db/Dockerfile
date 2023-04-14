
FROM mcr.microsoft.com/mssql/server:2017-CU27-ubuntu-16.04

RUN mkdir -p /usr/src/app
WORKDIR /usr/src/app
COPY ./content.sql /opt/mssql-scripts/content.sql

ENV MSSQL_SA_PASSWORD=?8@dtjFy#XCQ9
ENV ACCEPT_EULA=Y

EXPOSE 1433

RUN ( /opt/mssql/bin/sqlservr --accept-eula & ) | grep -q "Service Broker manager has started" \
    && /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P '?8@dtjFy#XCQ9' -i /opt/mssql-scripts/content.sql \
    && pkill sqlservr