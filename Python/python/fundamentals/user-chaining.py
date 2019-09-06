class User:
    def __init__(self,user_name,email_address):
        self.name = user_name
        self.email = email_address
        self.account_balance = 0
    
    def make_deposit(self,amount):
        self.account_balance += amount
        return self

    def make_withdrawl(self,amount):
        self.account_balance -= amount
        return self

    def display_user_balance(self):
        print(f"User: {self.name}, Balance: $ {round(self.account_balance,2)}")
        return self

    def transfer_money(self,other_user,amount):
        self.make_withdrawl(amount)
        other_user.make_deposit(amount)
        return self


john = User("John Smith","john_smith34654@email.com")
jane = User("Jane Jones","janejones57238654@email.com")
jose = User("Jose Enrique García Ramírez de Arroyo Santa Cruz y Hidalgo","jose@email.com")

john.make_deposit(1).make_deposit(3.50).make_deposit(0.23).make_withdrawl(500).display_user_balance()

jane.make_deposit(253).make_deposit(577).make_withdrawl(364).make_withdrawl(466).display_user_balance()

jose.make_deposit(1530).make_withdrawl(.01).make_withdrawl(2.71).make_withdrawl(3.14).display_user_balance()

john.transfer_money(jose,50).display_user_balance()
jose.display_user_balance()