class BankAccount:
    def __init__(self,int_rate=0.01,balance=0):
        self.interest_rate = int_rate
        self.balance = balance

    def deposit(self,amount):
        self.balance += amount
        return self
    
    def withdraw(self,amount):
        if self.balance - amount < 0:
            print("Insufficient funds: Charging a $5 fee.")
            self.balance -= (amount + 5)
        else:
            self.balance -= amount
        return self

    def display_account_info(self):
        print(f"Balance: {round(self.balance,2)}")
        return self

    def yield_interest(self):
        if self.balance > 0:
            self.balance *= (1 + self.interest_rate)
        return self

john_account = BankAccount()
jane_account = BankAccount(0.05)

john_account.deposit(50).deposit(10).deposit(1.38).withdraw(245).yield_interest().display_account_info()
jane_account.deposit(2000).deposit(822).withdraw(212).withdraw(1337).withdraw(3.50).withdraw(4.12).yield_interest().display_account_info()


