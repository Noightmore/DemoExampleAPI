CREATE PROCEDURE user_DeleteOne_ById(id_in int)

AS
$BODY$
BEGIN
    DELETE
    FROM
        person
    WHERE
        id = id_in;
END;
$BODY$

LANGUAGE plpgsql