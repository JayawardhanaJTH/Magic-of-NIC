package servlet;

import models.Details;
import services.Generate;
import services.IValidate;
import services.ValidateImplement;

import javax.servlet.RequestDispatcher;
import javax.servlet.http.HttpSession;
import java.io.IOException;
import java.time.LocalDate;

public class FindServlet extends javax.servlet.http.HttpServlet
{
    public FindServlet(){
        super();
    }

    protected void doPost(javax.servlet.http.HttpServletRequest request, javax.servlet.http.HttpServletResponse response) throws javax.servlet.ServletException, IOException
    {
        String _number = request.getParameter("nic_number");

        Generate _generate = new Generate();
        Details _details;
        String _error;
        HttpSession _session = request.getSession();

        _details = _generate.GenerateData(_number);

        try
        {
            if(_details == null)
            {
                _error = "The entered NIC is invalid";
                _session.setAttribute("ERROR", _error);
            }
            else
            {
                LocalDate _date = LocalDate.of(_details.getYear(), _details.getMonth(), _details.getDay());

                _session.setAttribute("SUCCESS", "yes");
                _session.setAttribute("BIRTHDAY", _date);
                _session.setAttribute("GENDER", _details.getGender());
            }
        }
        catch (Exception msg)
        {
            _error = msg.getMessage();
            _session.setAttribute("ERROR", _error);
        }

        RequestDispatcher dispatcher = getServletContext().getRequestDispatcher("/Index.jsp");
        dispatcher.forward(request,response);
    }

    protected void doGet(javax.servlet.http.HttpServletRequest request, javax.servlet.http.HttpServletResponse response) throws javax.servlet.ServletException, IOException
    {
        RequestDispatcher dispatcher = getServletContext().getRequestDispatcher("/Index.jsp");
        dispatcher.forward(request,response);
    }
}
