import { Outlet } from "react-router-dom";

const Layout = () => {
    return (
        <div className="container">
           
            <main className="main">
                <Outlet />
                <p> majmok gyertek </p>
            </main>

        </div>
    );
};

export default Layout;