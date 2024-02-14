# MassageStudio
<h2>Description</h2>
<p>MassageStudio is a simple webside model for massage studios, with more workers (can be used also for one worker).</p>
<p>Clients can reserve terms with specify massage type.</p>
<p>Masseurs can add new terms for clients and manage them.</p>
<p>Admins can manage massages, massage types and every account.</p>
<h2>Tech specifications</h2>
<p>Webside is write in  ASP.NET Core MVC (.NET 7), Entity Framework in Clean Architecture and CQRS (from MediatR), is connected to database using ORM code-first.</p>
<p>
  Important packages used:
  <ul>
    <li>auto mapper (AutoMapper)</li>
    <li>Validator package (FluentValidator)</li>
    <li>mediator (MediaR)</li>
    <li>Identity (Microsoft.AspNetCore.Identity)</li>
  </ul>
</p>
<p>At this moment application does not have Views, only backennd side</p>
