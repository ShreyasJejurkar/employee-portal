import { Route, Routes } from "react-router-dom";
import EmployeeList from "./Pages/EmployeeList";
import EmployeeDetails from "./Pages/EmployeeDetails";
import CreateEmployee from "./Pages/CreateEmployee";

const App = () => {
  return (
    <>
      <Routes>
        <Route path="/employee/:id" element={<EmployeeDetails />} />
        <Route path="/employee/create" element={<CreateEmployee />} />
        <Route path="/" element={<EmployeeList />} />
      </Routes>
    </>
  )
}

export default App;
