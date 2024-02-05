export interface Paymast {
    id: string,
    employeeId : string;
    fixTaxRate: number,
    baseMonthly: number,
    base15th: number,
    baseMonthEnd: number,
    colaMonthly: number,
    cola15th: number,
    colaMonthEnd: number,
    empShare: number,
    medAllowance: number,
    dailyShare: number,
    depName: string,
    depBirthday: string,
    ctcNo: string,
    dateIssue: string,
    rateType: string,
    placeIssue: string,
    payslipPinNo: string,
    excPayrollProcess: true
}