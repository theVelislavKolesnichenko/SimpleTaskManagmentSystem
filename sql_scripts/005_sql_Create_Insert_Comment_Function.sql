-- FUNCTION: public."Insert_Comment"(integer, integer, date, text, commentstype, date)

-- DROP FUNCTION public."Insert_Comment"(integer, integer, date, text, commentstype, date);

CREATE OR REPLACE FUNCTION public."Insert_Comment"(
	"ownerId" integer,
	"taskId" integer,
	"dateAdded" date,
	comment text,
	type commentstype,
	"reminderDate" date)
    RETURNS void
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$
BEGIN

	INSERT INTO public."Comments"(
	"OwnerId", "TaskId", "DateAdded", "Comment", "Type", "ReminderDate")
	VALUES (ownerId, taskId, dateAdded, "comment", "type", reminderDate);

END;
$BODY$;

ALTER FUNCTION public."Insert_Comment"(integer, integer, date, text, commentstype, date)
    OWNER TO postgres;
