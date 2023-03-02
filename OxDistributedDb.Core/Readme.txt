Localhost connection string
SETX OXNOSQL_CONNECTIONSTRING DatabaseName=OxQuote;ConnectionString=mongodb://localhost:27017
Azure cosmos connection string
SETX OXNOSQL_CONNECTIONSTRING DatabaseName=OxQuote;ConnectionString=mongodb://orooxlabadmintest:hPVCXiOa89nzEzXDAoC4f1vSZH1F2pmaJz4wWbFQ4u8k6DOBh2mXKMEoNnXRsp0pqedZXvGbWQVFACDbf4zWag==@orooxlabadmintest.mongo.cosmos.azure.com:10255/?ssl=true&retrywrites=false&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@orooxlabadmintest@
Server web.config connection string
<environmentVariable name="OXNOSQL_CONNECTIONSTRING" value="DatabaseName=OxQuote;ConnectionString=mongodb://orooxlabadmintest:hPVCXiOa89nzEzXDAoC4f1vSZH1F2pmaJz4wWbFQ4u8k6DOBh2mXKMEoNnXRsp0pqedZXvGbWQVFACDbf4zWag==@orooxlabadmintest.mongo.cosmos.azure.com:10255/?ssl=true&#38;retrywrites=false&#38;replicaSet=globaldb;maxIdleTimeMS=120000&#38;appName=@orooxlabadmintest@" />