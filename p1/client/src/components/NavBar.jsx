import { Link } from "react-router-dom";
const NavBar = () => {
  return (
    <div className="navbar bg-zinc-600 font-mono text-amber-400">
      <div className="flex-1">
        <Link to="/user">
          <h2 className="text-2xl font-bold pl-6  hover:scale-110 hover:text-cyan-400">
            Quiz App
          </h2>
        </Link>
      </div>
      <div className="flex-none">
        <ul className="menu menu-horizontal px-1 text-xl ">
          <li>
            <Link to="/user" className="hover:scale-110 hover:text-cyan-400">
              Profile
            </Link>
          </li>
          <li>
            <details className="pr-6">
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
        </ul>
      </div>
    </div>
  );
};

export default NavBar;
