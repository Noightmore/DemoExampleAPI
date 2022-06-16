CREATE FUNCTION user_UpdateInstance(id_in int, first_n text, last_n text, gender_in text, email_in text, date_of_birth_in text)
    RETURNS void
AS
$BODY$
BEGIN
    update person
    SET
            first_name = cast(first_n AS varchar),
            last_name = cast(last_n AS varchar),
            email = cast(email_in AS varchar),
            gender = (gender_in = 'male'),
            date_of_birth = cast(date_of_birth_in AS date)
    WHERE id = id_in;
END
$BODY$
LANGUAGE plpgsql