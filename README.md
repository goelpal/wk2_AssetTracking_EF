# wk2_AssetTracking_EF
# Asset Tracking with database and Entity Framework Core

##**INTRODUCTION**
1. This project is the start of an Asset Tracking database
2. Asset Tracking is a way to keep track of the company assets, like Laptops, Stationary computers, phones and so
on.
3. All assets have an end of life which for simplicity reasons is 3 years.
4. All assets needs to be stored in database using Entity Framework Core. 

##**REQUIREMENTS**
**A. Create a console app that have the following classes and objects:**
1. Computers
- MacBook
- Asus
- Lenovo
2. Phones
- Iphone
- Samsung
- Nokia
3. You will need to create the appropriate fields, constructors and properties for each object, like purchase date,
price, model name etc.
4. All assets needs to be stored in database using Entity Framework Core with Create and Read functionality.
5. Add offices to the model:
You should be able to place items in 3 different offices around the world which will use the appropriate currency
for that country. You should be able to input values in dollars and convert them to each currency (based on
todays currency charts)
6. When you write the list to the console:
 • Sorted first by office
 • Then Purchase date
 • Items *RED* if date less than 3 months away from 3 years
 • Items *Yellow* if date less than 6 months away from 3 years
 • Each item should have currency according to country
7. Your application should handle FULL CRUD.
8. Your application should have some reporting features.
