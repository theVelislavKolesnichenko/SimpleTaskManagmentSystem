-- FUNCTION: public."Search_Comment"(character varying)

-- DROP FUNCTION public."Search_Comment"(character varying);

CREATE OR REPLACE FUNCTION public."Search_Comment"(
	"searchText" character varying)
    RETURNS SETOF "Comments" 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$
BEGIN
	RETURN QUERY
	SELECT "OwnerId", "TaskId", "DateAdded", "Comment", "Type", "ReminderDate"
	FROM public."Comments"
	WHERE "Comment" LIKE '%' + "searchText" + '%';
END;
$BODY$;

ALTER FUNCTION public."Search_Comment"(character varying)
    OWNER TO postgres;
