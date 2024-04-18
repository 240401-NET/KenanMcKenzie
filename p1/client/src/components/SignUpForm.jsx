import { useState } from "react";
import { useNavigate, Link } from "react-router-dom"
import { signUp } from "../api/userService"
import logo from "../assets/quizlogo.png"
const SignUpForm = () => {
  //email, username, password
  const [email, setEmail] = useState("")
  const [password, setPassword] = useState("")
  const [confirmPassword, setConfirmPassword] = useState("")
  const [name, setName] = useState("")

  const navigate = useNavigate();

  const handleSignup = async (e) => {
    e.preventDefault()
    try {
      const response = await signUp(name, email, password)
      console.log(response)
      navigate("/user")
  
    } catch (error) {
      console.error(error)
    }
  }

  

  const inputClass = "block w-full rounded-md border-0 pl-2 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600"
  const labelClass = "block text-sm font-medium leading-6 text-gray-900"
  return (
    <div className="flex min-h-full flex-col justify-center px-6 py-12 lg:px-8">
  <div className="sm:mx-auto sm:w-full sm:max-w-sm">
    <img className="mx-auto h-32 w-auto" src={logo} alt="Your Company" />
    <h2 className="mt-10 text-center text-2xl font-bold leading-9 tracking-tight text-gray-900">Create an account</h2>
  </div>

  <div className="mt-10 sm:mx-auto sm:w-full sm:max-w-sm">
    <form className="space-y-6" onSubmit={handleSignup}>
      <div>
        <label className={labelClass}>Username</label>
        <div className="mt-2">
          <input 
          type="text" 
          value={name}
          required 
          className={inputClass}
          onChange={(e) => setName(e.target.value)}
          />
        </div>
      </div>

      
      <div>
        <label htmlFor="email" className={labelClass}>Email</label>
        <div className="mt-2">
          <input 
          id="email" 
          type="email" 
          autoComplete="email" 
          value={email}
          required 
          className={inputClass}
          onChange={(e) => setEmail(e.target.value)}
          />
        </div>
      </div>

      <div>
        <div className="flex items-center justify-between">
          <label htmlFor="password" className={labelClass}>Password</label>
          
        </div>
        <div className="mt-2">
          <input 
          id="password" 
          type="password" 
          value={password}
          required 
          className={inputClass}
          onChange={(e) => setPassword(e.target.value)}
          />
        </div>
      </div>
      <div>
        <div className="flex items-center justify-between">
          <label htmlFor="password" className={labelClass}>Confirm Password</label>
          
        </div>
        <div className="mt-2">
          <input 
          id="password" 
          type="password" 
          value={confirmPassword}
          required 
          className={inputClass}
          onChange={(e) => setConfirmPassword(e.target.value)}
          />
        </div>
      </div>

      <div>
        <button type="submit" className="flex w-full justify-center rounded-md bg-indigo-600 px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600">Sign in</button>
      </div>
    </form>

    <p className="mt-10 text-center text-sm text-gray-500">
  Already a member?
  <Link to="/signin" className="font-semibold leading-6 text-indigo-600 hover:text-indigo-500"> Sign In</Link>
</p>
  </div>
</div>
  )
}

export default SignUpForm