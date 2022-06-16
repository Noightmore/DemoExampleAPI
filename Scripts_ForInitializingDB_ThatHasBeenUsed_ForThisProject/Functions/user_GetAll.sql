CREATE FUNCTION user_GetAll()
    RETURNS table(
        UID int,
        UFirstName varchar,
        ULastName varchar,
        UGender varchar,
        UEmail varchar,
        UBirthDate date
    )
AS
$BODY$
BEGIN
     RETURN QUERY SELECT
        cast(id AS integer),
        first_name,
        last_name,
        CASE
            WHEN gender THEN cast('male' AS varchar)
            ELSE cast('female' AS varchar)
        END,
        email,
        date_of_birth

    FROM
        person;
END;
$BODY$
LANGUAGE plpgsql