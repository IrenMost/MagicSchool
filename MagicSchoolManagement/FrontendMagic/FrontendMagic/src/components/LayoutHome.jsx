
import { Outlet } from "react-router-dom";



const LayoutHome = () => {
  
    return (
        <div className="container">

            <main className="main">
                <Outlet />
                
                
            </main>

        </div>
    );
};

export default LayoutHome;