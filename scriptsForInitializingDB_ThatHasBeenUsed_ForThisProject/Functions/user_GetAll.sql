CREATE FUNCTION user_GetAll()
    RETURNS table(
        UID int,
        UFirstName varchar,
        ULastName varchar,
        UGender boolean,
        UEmail varchar,
        UBirthDate date
    )
AS
$BODY$
BEGIN
     RETURN QUERY SELECT
        cast(id AS int),
        first_name,
        last_name,
        gender,
        email,
        date_of_birth

    FROM
        person;
END;
$BODY$
LANGUAGE plpgsql