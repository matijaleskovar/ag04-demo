# ag04-demo
Demo ag04 application

## Requirements
- .Net Core Framework 3.1

## Application set up
1. Create empty MS/SQL database and name it "AG04Demo"
2. In "appsettings.json" modify connection string to match database connection if needed
3. Update database with EF migrations
4. Run InitialSeed.sql (DataAccessLayer/SqlScripts) on your database
5. Run application ag04-demo
