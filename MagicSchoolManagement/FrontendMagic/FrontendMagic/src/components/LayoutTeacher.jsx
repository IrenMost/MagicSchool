import { Outlet } from "react-router-dom";

const LayoutTeacher = () => {
    return (
        <div className="container">
           
            <main className="main">
                <Outlet />
                <p> tanarak gyertek </p>
            </main>

        </div>
    );
};

export default LayoutTeacher;