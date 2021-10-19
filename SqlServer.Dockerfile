FROM mcr.microsoft.com/mssql/server

ARG SECRET

# Set sql server settings
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=$SECRET
ENV MSSQL_PID=Developer