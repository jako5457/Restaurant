# Wait to be sure that SQL Server came up
echo "Waiting for sqlserver to start"
sleep "90s"
if [ !-e /usr/src/app/Scripts/HasDelployed.txt ]
then
	echo "Deploying Database...."
	# Run the setup script to create the DB and the schema in the DB
	# Note: make sure that your password matches what is in the Dockerfile
	/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $1 -d master -i /usr/src/app/Scripts/Database.sql
fi
touch /usr/src/app/Scripts/HasDelployed.txt