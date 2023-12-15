//export const dateFormatDbView = () => {
// Caso tenha somente um parametro os () podem ser substituidos pelo nome.
//} 
export const dateFormatDbToView = data => {
    // Ex: 2023-09-30T00:00:00 para 30-09-2023

    data = data.substr(0, 10);//retorna apenas a data (2023-09-30)
    data = data.split("-");//[2023, 09, 30]


    return `${data[2]}/${data[1]}/${data[0]}`;//30/09/2023
    

}
