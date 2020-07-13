-- FUNCTION: public."Select_Tasks"()

-- DROP FUNCTION public."Select_Tasks"();

CREATE OR REPLACE FUNCTION public."Select_Tasks"(
	)
    RETURNS SETOF "Tasks" 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$
BEGIN
	RETURN QUERY
	SELECT "Id", "CreatedDate", "RequiredByDate", "Description", "Status", "Type" 
	FROM public."Tasks";
END;
$BODY$;

ALTER FUNCTION public."Select_Tasks"()
    OWNER TO postgres;
