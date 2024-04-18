import { Link, useNavigate } from "react-router-dom";
import logo from "../assets/quizlogo.png";
import axios from "axios";

const NavBar = () => {
  const navigate = useNavigate();

  const loggedIn = localStorage.getItem("user");

  const handleLogout = async () => {
    const response = await axios.get("api/user/logout", {
      withCredentials: true,
    });
    const data = await response.json();
    if (response.ok) {
      localStorage.removeItem("user");
      navigate("/");
    } else {
      console.error(data.message);
      return (
        <div className="toast toast-top toast-center">
          <div className="error error-info">
            <span>New mail arrived.</span>
          </div>
        </div>
      );
    }
  };

  return (
    <div className="navbar bg-zinc-600 font-mono text-amber-400">
      <div className="flex-1">
        <Link
          to="/"
          className="flex hover:scale-110 hover:text-cyan-400 items-center"
        >
          <h2 className="text-2xl font-bold pl-10 pr-4  ">Quiz App</h2>
          <img src={logo} alt="logo" className="h-12 w-12" />
        </Link>
      </div>
      <div className="flex-none">
        <ul className="menu menu-horizontal pr-12 text-xl ">
          <li>
            <details>
              <summary className="hover:scale-110 hover:text-cyan-400">
                Quizzes
              </summary>
              <ul className="p-2 bg-zinc-600 rounded-t-none ">
                <li className="hover:text-cyan-400">
                  <Link to="/create">Create</Link>
                </li>
                <li className="hover:text-cyan-400">
                  <Link to="/user">Saved</Link>
                </li>
              </ul>
            </details>
          </li>
          <li className="text-amber-400">
            {loggedIn ? (
              <button
                className="hover:scale-110 hover:text-cyan-400 text-amber-400"
                onClick={handleLogout}
              >
                Logout
              </button>
            ) : (
              <Link
                to="/signin"
                className="hover:scale-110 hover:text-cyan-400 text-amber-400 focus:text-amber-400"
              >
                Login
              </Link>
            )}
          </li>
        </ul>
      </div>
    </div>
  );
};

export default NavBar;
