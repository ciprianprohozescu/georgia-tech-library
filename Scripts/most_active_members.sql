select Member.id, ssn, fname, lname, count(Loan.loan_date) as loans_all_time, 
case when sum(case when Loan.loan_date >= DATEADD(MONTH, -1, GETDATE()) then 1 end) is not null 
then sum(case when Loan.loan_date >= DATEADD(MONTH, -1, GETDATE()) then 1 end) 
else 0 end as loans_last_month, 
case when sum(case when (Loan.return_date is null or Loan.return_date > Loan.due_date) then 1 end) is not null
then sum(case when (Loan.return_date is null or Loan.return_date > Loan.due_date) then 1 end)
else 0 end as loans_overdue 
from Member
join Loan on Member.id = Loan.member_id
group by Member.id, Member.ssn, Member.fname, Member.lname
order by loans_all_time desc;
