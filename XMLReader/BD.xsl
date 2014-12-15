

<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:output method='html'/>

	
	
	
	<xsl:template match="libraryDatabase">
	  <HTML>
		<BODY>
		  <TABLE BORDER="2">
			<TR>
			  <TD>Ім'я</TD>
			  <TD>автор</TD>
			  <TD>Видавництво</TD>
			  <TD>Рік</TD>
			  <TD>Кількість сторінок</TD>
			  <TD>Тираж</TD>
			  <TD>Мова</TD>
			</TR>
			<xsl:apply-templates select="book"/>
		  </TABLE>
		</BODY>
	  </HTML>
	</xsl:template>	
	
	<xsl:template match="book">
	  <TR>
		<TD><xsl:value-of select="@NAME"/></TD>
		<TD><xsl:value-of select="info/@autor"/></TD>
		<TD><xsl:value-of select="info/@publishingHouse"/></TD>
		<TD><xsl:value-of select="info/@year"/></TD>
		<TD><xsl:value-of select="info/@pageCount"/></TD>
		<TD><xsl:value-of select="info/@printingCount"/></TD>
		<TD><xsl:value-of select="info/@language"/></TD>
		
		
	  </TR>
	 
	</xsl:template>
	</xsl:stylesheet>