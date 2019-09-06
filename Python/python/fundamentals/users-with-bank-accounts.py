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


class User:
    def __init__(self,user_name,email_address,account_list=[["Checking",0.02,0]]):
        self.name = user_name
        self.email = email_address
        self.accounts = {}
        for account in account_list:
            self.accounts[account[0]] = BankAccount(account[1],account[2]) 
    
    def make_deposit(self,amount,account_name="Checking"):
        self.accounts[account_name].deposit(amount)
        return self

    def make_withdrawl(self,amount,account_name="Checking"):
        self.accounts[account_name].withdraw(amount)
        return self

    def display_user_balance(self,account_name="Checking"):
        print(f"User: {self.name}, Account: {account_name}, Balance: ${round(self.accounts[account_name].balance,2)}, Interest Rate: {self.accounts[account_name].interest_rate}")
        return self

    def transfer_money(self,other_user,amount,account_name="Checking",other_account_name="Checking"):
        self.accounts[account_name].withdraw(amount)
        other_user.accounts[other_account_name].deposit(amount)
        return self

john = User("John Smith","jsmith@gmail.com")
jane = User("Jane Jones","jjones@gmail.com",[["Checking",0.01,250],["Saving",0.05,1560]])

john.make_deposit(100).make_deposit(150).make_withdrawl(260).display_user_balance()
jane.make_deposit(100,"Checking").make_withdrawl(12,"Checking").display_user_balance("Checking")
jane.make_deposit(53,"Saving").make_withdrawl(66,"Saving").display_user_balance("Saving")
jane.accounts['Saving'].yield_interest().display_account_info()
john.transfer_money(jane,100,"Checking","Saving").display_user_balance()
jane.display_user_balance('Saving')
jane.transfer_money(jane,250,"Checking","Saving").display_user_balance("Checking").display_user_balance("Saving")