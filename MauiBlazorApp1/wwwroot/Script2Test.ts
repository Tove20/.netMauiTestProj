module Script2Test {

    export function SayHello() {
        Greet("hello world", 1);
    }

    export function Greet(text: string, nr: number) {
        console.log(text);
        document.getElementById("btnSayHello").innerText = text + nr.toString();
    }

}