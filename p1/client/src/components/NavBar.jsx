import { Link } from "react-router-dom"
const NavBar = () => {
  return (
    <div className="navbar bg-base-100">
  <div className="flex-1">
    <a className="btn btn-ghost text-xl">Title</a>
  </div>
  <div className="flex-none">
    <ul className="menu menu-horizontal px-1">
      <li><a>Profile</a></li>
      <li>
        <details>
          <summary>
            Quizzes
          </summary>
          <ul className="p-2 bg-base-100 rounded-t-none">
            <li><Link to="/create">Create</Link></li>
            <li><a>Saved (Open drawer?)</a></li> 
            <li><Link to="/popular">Popular</Link></li>
          </ul>
        </details>
      </li>
    </ul>
  </div>
</div>
  )
}

export default NavBar