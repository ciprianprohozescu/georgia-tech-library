create function volume_loans(@bookId INTEGER, @volumeId INTEGER)
returns INTEGER
as
begin
    declare @loans INTEGER;
    select @loans = count(loan_date) from Loan where book_id = @bookId and volume_id = @volumeId;
    return @loans
end

drop function volume_loans;

select id, book_id, dbo.volume_loans(Volume.book_id, Volume.id) as loans
from Volume