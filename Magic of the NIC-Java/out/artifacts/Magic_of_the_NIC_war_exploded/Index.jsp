<%@ page import="java.util.logging.Logger" %>
<%@ page import="java.time.LocalDate" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>

<jsp:include page="WEB-INF/Includes/Header.jsp"/>
<div class="container">
  <div class="row d-flex justify-content-center align-items-center h-75">
    <form method="post" action="FindServlet">
      <div class="form-group">
        <lable>Enter your NIC number</lable>
        <input type="text" name="nic_number" placeholder="123456789V/111123456789" class="form-control">
      </div>
      <div class="form-group">
        <input type="submit" name="find" value="Find" class="btn btn-success">
      </div>
    </form>
  </div>
    <%
        try
        {
            if(session.getAttribute("ERROR") != null)
            {
                String _error = (String) session.getAttribute("ERROR");
                session.removeAttribute("ERROR");
    %>
    <div class="row d-flex justify-content-center align-items-center">
      <div>
          <h4 class="text-danger"><%=  _error%></h4>
      </div>
    </div>
    <%
            }
            else if(session.getAttribute("SUCCESS").equals("yes"))
            {
                LocalDate _date = (LocalDate) session.getAttribute("BIRTHDAY");
                String _birthDay = _date.toString();
                String _gender = (String) session.getAttribute("GENDER");
                session.removeAttribute("BIRTHDAY");
                session.removeAttribute("GENDER");
     %>
        <div class="row d-flex justify-content-center align-items-center">
            <div>
              <h4 class="text-dark">Your Birth Day is : <%=  _birthDay%></h4>
              <h4 class="text-dark">Your Gender is : <%=  _gender%></h4>
            </div>
        </div>
    <%
            }
        }
        catch (NullPointerException ex)
        {

        }

    %>

</div>

