select Book.title, Volume.id as volume_id, 
case when exists (select loan_date from Loan where Volume.id = Loan.volume_id and Book.id = Loan.book_id and return_date is null) then 'not available' else 'available' end as status
from Volume
join Book on Volume.book_id = Book.id
where Book.title like '%'
