CREATE FUNCTION user_GetOne_ById(id_in int)
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
        cast(id AS integer),
        first_name,
        last_name,
        gender,
        email,
        date_of_birth
    FROM
        person
    WHERE
        id = id_in;
END;
$BODY$

LANGUAGE plpgsql