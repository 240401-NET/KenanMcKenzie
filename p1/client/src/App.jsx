import { BrowserRouter as Router, Routes, Route } from "react-router-dom"
import NavBar from "./components/NavBar"
import Landing from "./pages/Landing"
import PopularQuizzes from "./pages/PopularQuizzes"
import UserQuizzes from "./pages/UserQuizzes"
import SignIn from "./pages/SignIn"
import SignUp from "./pages/SignUp"

function App() {

  return (
   
      <Router>
        <NavBar />
        <Routes>
          <Route path="/" element={<Landing />} />
          <Route path="/popular" element={<PopularQuizzes />} />
          <Route path="/user" element={<UserQuizzes />} />
          <Route path="/signin" element={<SignIn />} />
          <Route path="/signup" element={<SignUp />} />
        </Routes>
      </Router>
  )
}



export default App
