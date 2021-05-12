create trigger trg_check_available_volume_on_loan
on Loan after insert
as begin
    if (select count(*) from Loan
        join inserted on Loan.book_id = inserted.book_id and Loan.volume_id = inserted.volume_id and Loan.return_date is null) > 1
        begin
            raiserror('Error. Volume already out on loan.', 17, 55)
            rollback tran
        end
end;

drop trigger trg_check_available_volume_on_loan;

insert into Loan (member_id, book_id, volume_id, loan_date, due_date) values (1, 51, 1, GETDATE(), DATEADD(MONTH, 1, GETDATE()));

select * from Loan
where book_id = 1 and volume_id = 1 and return_date is null;