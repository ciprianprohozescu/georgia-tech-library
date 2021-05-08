select ssn, fname, lname, count(alltime.loan_date) as loans_all_time, count(lastmonth.loan_date) as loans_last_month, count(overdue.loan_date) / count(alltime.loan_date) * 100 as loans_overdue 
from Member
join Loan as alltime on Member.id = alltime.member_id
join Loan as lastmonth on Member.id = lastmonth.member_id
join Loan as overdue on Member.id = overdue.member_id
where lastmonth.loan_date >= DATEADD(MONTH, -1, GETDATE()) and (overdue.return_date is null or overdue.return_date > overdue.loan_date)
group by Member.id, Member.ssn, Member.fname, Member.lname
order by loans_all_time desc;