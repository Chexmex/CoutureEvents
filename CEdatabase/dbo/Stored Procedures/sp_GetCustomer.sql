CREATE PROCEDURE sp_GetCustomer AS
SELECT
	ID,
	BrideFirstName,
	BrideLastName,
	GroomFirstName,
	GroomLastName,
	PhoneNumber,
	Email,
	[Address],
	City,
	WeddingDate,
	NumberOfGuests,
	NumberOfBridesmaids,
	NumberOfGroomsmen,
	[Password]
FROM
	Customer