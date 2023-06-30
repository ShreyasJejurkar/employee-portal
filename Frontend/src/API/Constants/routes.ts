export const API_BASE_URL = 'http://localhost:5003/api';

export const EmployeeRoutes = {
    GetAllEmployees: `${API_BASE_URL}/Employee/Get`,
    GetEmployeeById: (id: number) => `${API_BASE_URL}/Employee/Get/${id}`,
    CreateEmployee: `${API_BASE_URL}/Employee/CreateEmployee`,
    DeleteEmployee: (id: number) => `${API_BASE_URL}/Employee/DeleteEmployee?id=${id}`,
}

export const CommentsRoutes = {
    GetCommentsByEmployeeId: (id: number) => `${API_BASE_URL}/Comments/GetCommentsByEmployeeId?employeeId=${id}`,
}