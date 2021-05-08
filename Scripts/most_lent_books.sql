select title, count(Loan.loan_date) as loans
from Book
join Loan on Book.id = Loan.book_id
group by Book.id, Book.title
order by loans desc;