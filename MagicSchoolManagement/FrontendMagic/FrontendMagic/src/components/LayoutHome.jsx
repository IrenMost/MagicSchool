import { createContext } from "react";
import { Outlet } from "react-router-dom";



const LayoutHome = () => {
    return (
        <div className="container">

            <main className="main">
                <Outlet />
                <p> welcome USER </p>
            </main>

        </div>
    );
};

export default LayoutHome;