# diet_app
University Project. Diet application in C#

## PostgreSQL Database Config.

1) Create Database:
   ```sql
   CREATE DATABASE dietdb;
   ```

2) Create custom user
	```sql
    CREATE USER diet;
	GRANT CONNECT ON DATABASE dietdb TO diet;
	GRANT ALL PRIVILEGES ON ALL TABLES IN SCHEMA public TO diet;
    ``` 

3) Set Up diet user for dietdb:
   ```sql
   ALTER DATABASE dietdb ONWER TO diet;
   ```

4) Open CMD:
	```java
	/* 
     * NOTES:
	 *    You must add to the system env. path the path to the psql/bin folder. 
	 *    The path must be similar to this: C:\Program Files\PostgreSQL\13\bin 
     */
	```
    ```
    ~ psql -U diet dietdb < dietdb.sql
    ```
