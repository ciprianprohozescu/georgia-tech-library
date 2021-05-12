import random
import json
from datetime import datetime
from datetime import timedelta
import time

random.seed()
f = open("populate_loan.sql", "w")

memberTotal = 10000
bookTotal = 10000

with open('book_volume_count.json') as jsf:
    volumeJson = json.load(jsf)
    volumeTotal = [0] * (bookTotal + 1)
    for volumeCount in volumeJson:
        volumeTotal[volumeCount['id']] = volumeCount['volumeNo']

for member in range(1, memberTotal + 1):
    loanTotal = random.randint(0, 15)
    for loan in range(1, loanTotal + 1):
        bookId = random.randint(1, bookTotal)
        if (volumeTotal[bookId] == 0):
            continue
        volumeId = random.randint(1, volumeTotal[bookId])

        startTime = time.mktime(datetime.strptime("01/01/2020", "%d/%m/%Y").timetuple())
        endTime = time.mktime(datetime.strptime("07/05/2021", "%d/%m/%Y").timetuple())
        loanTime = random.randint(startTime, endTime)
        loanDateTime = datetime.fromtimestamp(loanTime)
        dueDateTime = loanDateTime + timedelta(days=21)
        loanLength = random.randint(6, 50)
        returnDateTime = loanDateTime + timedelta(days=loanLength)
        if loanLength == 6:
            f.write(f'insert into Loan (member_id, volume_id, book_id, loan_date, due_date) values ({member}, {volumeId}, {bookId}, \'{loanDateTime.strftime("%Y%m%d")}\', \'{dueDateTime.strftime("%Y%m%d")}\');\n')
        else:
            f.write(f'insert into Loan (member_id, volume_id, book_id, loan_date, return_date, due_date) values ({member}, {volumeId}, {bookId}, \'{loanDateTime.strftime("%Y%m%d")}\', \'{returnDateTime.strftime("%Y%m%d")}\', \'{dueDateTime.strftime("%Y%m%d")}\');\n')