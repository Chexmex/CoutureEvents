/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
INSERT INTO
	Customer(BrideFirstName, BrideLastName, GroomFirstName,GroomLastName,PhoneNumber,Email,[Address],City,WeddingDate,NumberOfGuests,NumberOfBridesmaids,NumberOfGroomsmen)
VALUES
	('BrideF','BrideL','GroomF','GroomL','phone#','email@address', '123main','city', 10-10-10, 50,5,5)
	