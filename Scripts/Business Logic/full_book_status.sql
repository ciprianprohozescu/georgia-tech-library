create procedure full_book_status
@title VARCHAR(255)
as
begin
    declare @bookId INTEGER, @volumeNo INTEGER, @counter INTEGER, @ssn VARCHAR(255), @fname VARCHAR(255), @lname VARCHAR(255), @loanDate DATE, @dueDate DATE;
    select top 1 @bookId = id from Book where title like '%' + @title + '%';
    print @title;
    print @bookId;
    select @volumeNo = count(id) from Volume where Volume.book_id = @bookId;
    if @volumeNo = 0
    begin
        print 'This book has no volumes';
        return;
    end
    set @counter = 1;
    while @counter <= @volumeNo
    begin
        set @loanDate = null;
        select top 1 @loanDate = Loan.loan_date, @dueDate = Loan.due_date, @ssn = Member.ssn, @fname = Member.fname, @lname = Member.lname
        from Loan
        join Member on Loan.member_id = Member.id
        where Loan.book_id = @bookId and Loan.volume_id = @counter and Loan.return_date is null;
        if @loanDate is null print concat('Volume ', @counter, ' is currently available')
        else print concat('Volume ', @counter, ' is currently held by ', @fname, ' ', @lname, ' (SSN ', @ssn, '), loaned on ', @loanDate, ', due on ', @dueDate);
        set @counter = @counter + 1;
    end
end

drop procedure full_book_status;

exec full_book_status 'Sands of Iwo Jima'
