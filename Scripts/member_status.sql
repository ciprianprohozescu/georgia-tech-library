select ssn, fname, minit, lname, count(Loan.loan_date) as currently_held_books from Member
left join Loan on Member.id = Loan.member_id
where Loan.return_date is null and Member.lname like '%a%'
group by Member.id, Member.ssn, Member.fname, Member.minit, Member.lname;