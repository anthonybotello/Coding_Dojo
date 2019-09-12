var myString: string = "This is a string";

var myNumber: number = 7;

var myBoolean: boolean = true;

var arrayOfNumbers: number[];

var arrayofNumbers: Array<number>

var anything: any = 7;

function errorHandler(message: string): never{
    throw new Error(message);
}

function printValue(val:string): void{
    console.log(val);
    return;
}
